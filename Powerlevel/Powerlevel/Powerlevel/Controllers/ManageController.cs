using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Powerlevel.Models;
using Powerlevel.Infastructure;
using System.Collections.Generic;
namespace Powerlevel.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        //This is for testing
        private IToasterRepository repo;

        public ManageController(IToasterRepository repository)
        {
            this.repo = repository;
        }

        //to get access to the database
        private toasterContext db = new toasterContext();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {

            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

            var userId = User.Identity.GetUserId();

            //get user level by their UserName, pass it into viewbag
            ViewBag.userCurrentLevel = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Level).FirstOrDefault();

            //get user exp points by their UserName, pass it into viewbag
            ViewBag.userExperiencePoints = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Experience).FirstOrDefault();

            //get user fitness level(BMI), pass into viewbag
            ViewBag.userBMI = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.BMI).FirstOrDefault();

            //get user height, pass into viewbag
            ViewBag.userHeightFeet = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.HeightFeet).FirstOrDefault();
            ViewBag.userHeightInch = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.HeightInch).FirstOrDefault();

            //get user weight, pass into viewbag
            ViewBag.userWeight = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Weight).FirstOrDefault();

            //get BMI description
            if (ViewBag.userBMI < 18.5)
            {
                ViewBag.BMIdecs = "Underweight";
            }
            if (ViewBag.userBMI > 18.5 && ViewBag.userBMI <= 24.9)
            {
                ViewBag.BMIdecs = "Normal weight";
            }
            if (ViewBag.userBMI >= 25 && ViewBag.userBMI <= 29.9)
            {
                ViewBag.BMIdecs = "Overweight";
            }
            if (ViewBag.userBMI >= 30)
            {
                ViewBag.BMIdecs = "Obesity";
            }
            //get the current logged-in user ID as an integer
            int userIdInt = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.UserId).FirstOrDefault();

            //check & see if the user already have an avatar
            var userValid = db.UserAvatars.Where(x => x.UserId == userIdInt).FirstOrDefault();
            //if user doesn't have an avatar
            if (userValid == null || userValid.Body == null)
            {
                GiveUserAvatar(userIdInt);
                userValid = db.UserAvatars.Where(x => x.UserId == userIdInt).FirstOrDefault();
            }
            //get user avatar
            ViewBag.userAvatarBody = userValid.Body.ToString();
            ViewBag.userAvatarArmor = userValid.Armor.ToString();
            ViewBag.userAvatarWeapon = userValid.Weapon.ToString();


            //get team members id
            var teamMemIdList = db.Teams.Where(x => x.UserId == userIdInt).Select(y => y.TeamMemId).ToList();

            //get team members name
            List<string> teamMemNameList = new List<string>();
            for (int i = 0; i < teamMemIdList.Count(); i++)
            {
                int? teamIdTemp = teamMemIdList[i]; //a temp buffer uses to do LINQ queries 
                if (teamIdTemp != null)
                {
                    //safety check, only add to list if not null
                    ViewBag.teamMessage = "150% Exp Bonus activated!";
                    var memName = db.Users.Where(x => x.UserId == teamIdTemp).Select(y => y.UserName).FirstOrDefault();
                    teamMemNameList.Add(memName);
                }
            }
            //get the total team member count, pass to view
            ViewBag.teamMemberCount = teamMemIdList.Count();

            //pass the team member name to view
            ViewBag.teamMemberName = teamMemNameList;

            //pass the team members Id to view
            ViewBag.teamMemberId = teamMemIdList;

            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
                Logins = await UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };

            return View(model);
        }

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("ManageLogins", new { Message = message });
        }

        //
        // GET: /Manage/AddPhoneNumber
        public ActionResult AddPhoneNumber()
        {
            return View();
        }

        //
        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Generate the token and send it
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
            if (UserManager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination = model.Number,
                    Body = "Your security code is: " + code
                };
                await UserManager.SmsService.SendAsync(message);
            }
            return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
        }

        //
        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnableTwoFactorAuthentication()
        {
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), true);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DisableTwoFactorAuthentication()
        {
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), false);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // GET: /Manage/VerifyPhoneNumber
        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber);
            // Send an SMS through the SMS provider to verify the phone number
            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        //
        // POST: /Manage/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePhoneNumberAsync(User.Identity.GetUserId(), model.PhoneNumber, model.Code);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "Failed to verify phone");
            return View(model);
        }

        //
        // POST: /Manage/RemovePhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemovePhoneNumber()
        {
            var result = await UserManager.SetPhoneNumberAsync(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.Error });
            }
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                    if (user != null)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    }
                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Manage/SetAvatar
        public ActionResult SetAvatar()
        {
            //check if user have avatar
            //get the current logged-in user Id
            int userId = repo.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.UserId).FirstOrDefault();

            // Create a list of all avatarBodies the user can have (OLD IMPLEMENTATION)
            //var SelectBody = db.Avatars.Where(x => x.Type.Equals("Body")).ToList();

            //Create a list of all the bodies a user has
            var avatarBodies = db.AvatarUnlocks.Where(x => x.UserId == userId).Where(x => x.Avatar.Type.ToString() == "Body").ToList();
            //If the user has no bodies unlocked
            if (avatarBodies.Count() == 0)
            {
                var noBodyList = db.Avatars.Where(x => x.Type == "Body").ToList();
                foreach (Avatar body in noBodyList)
                {
                    AvatarUnlock adder = new AvatarUnlock();
                    adder.AvaId = body.AvaId;
                    adder.UserId = userId;
                    db.AvatarUnlocks.Add(adder);
                    db.SaveChanges();
                }
                avatarBodies = db.AvatarUnlocks.Where(x => x.UserId == userId).Where(x => x.Avatar.Type.ToString() == "Body").ToList();
            }

            //Create a list of the avatars to pass
            System.Collections.Generic.List<Avatar> SelectBody = new System.Collections.Generic.List<Avatar>();
            foreach (AvatarUnlock avaUnlk in avatarBodies)
            {
                //Get the current avatar object from the users list based on the avatar id
                Avatar adder = db.Avatars.Where(x => x.AvaId == avaUnlk.AvaId).First();
                //Add that avatar object to the list of avatar objects
                SelectBody.Add(adder);
                System.Diagnostics.Debug.WriteLine(adder.Name.ToString());
            }

            return View(SelectBody);
        }

        //
        // POST: /Manage/SetAvatar
        [HttpPost]
        public ActionResult SetAvatar(string selected_avatar)
        {
            //get the current logged-in user's id
            var userId = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.UserId).FirstOrDefault();

            //update the user selected avatar to the database
            //UserAvatar userAvatars = new UserAvatar();
            UserAvatar userAvatars = db.UserAvatars.Where(x => x.UserId == userId).Select(x => x).ToList().FirstOrDefault(); //find the user column in the database table\
            Avatar requestAvatarItem = db.Avatars.Where(x => x.Imagefile == selected_avatar).FirstOrDefault();

            userAvatars.Body = selected_avatar; //change their avatar body
            userAvatars.Race = requestAvatarItem.Race; // change the avatar race
            //Clear current gear and armor
            userAvatars.Weapon = "none.PNG";
            userAvatars.Armor = "none.PNG";
            db.Entry(userAvatars).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult SetArmor()
        {
            //get the current logged-in user Id
            int userId = repo.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.UserId).FirstOrDefault();

            //Create a list of all armor a user has
            var avatarArmor = db.AvatarUnlocks.Where(x => x.UserId == userId).Where(x => x.Avatar.Type.ToString() == "Armor").ToList();
            //If the user has no armor unlocked
            if (avatarArmor.Count() == 0)
            {
                // Add defualt armor of each race (ie none) to user's unlocks
                var noArmorList = db.Avatars.Where(x => x.Name == "none").Where(x => x.Type == "Armor").ToList();
                foreach (Avatar arm in noArmorList)
                {
                    AvatarUnlock adder = new AvatarUnlock();
                    adder.AvaId = arm.AvaId;
                    adder.UserId = userId;
                    db.AvatarUnlocks.Add(adder);
                    db.SaveChanges();
                }
                avatarArmor = db.AvatarUnlocks.Where(x => x.UserId == userId).Where(x => x.Avatar.Type.ToString() == "Weapon").ToList();
            }

            //Create a list of the avatars to pass
            System.Collections.Generic.List<Avatar> SelectArmor = new System.Collections.Generic.List<Avatar>();
            foreach (AvatarUnlock avaUnlk in avatarArmor)
            {
                //Get the current avatar object from the users list based on the avatar id
                Avatar adder = db.Avatars.Where(x => x.AvaId == avaUnlk.AvaId).First();
                //Add that avatar object to the list of avatar objects if we don't have an object of the same name
                if (SelectArmor.Any(x => x.Name == adder.Name) == false)
                {
                    SelectArmor.Add(adder);
                    System.Diagnostics.Debug.WriteLine(adder.Name.ToString());
                }
            }
            return View(SelectArmor);
        }

        //
        // POST: /Manage/SetArmor
        [HttpPost]
        public ActionResult SetArmor(string selected_armor)
        {
            //get the current logged-in user's id
            var userId = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.UserId).FirstOrDefault();

            //update the user selected avatar to the database
            UserAvatar userAvatars = db.UserAvatars.Where(x => x.UserId == userId).Select(x => x).ToList().FirstOrDefault(); //find the user entry in the database table
            // Get the needed avatar based on current race
            Avatar requestAvatarItem = db.Avatars.Where(x => x.Name == selected_armor).Where(x => x.Race == userAvatars.Race).Where(x => x.Type == "Armor").FirstOrDefault();

            userAvatars.Armor = requestAvatarItem.Imagefile; //change their avatar armor
            db.Entry(userAvatars).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult SetWeapon()
        {
            //get the current logged-in user Id
            int userId = repo.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.UserId).FirstOrDefault();

            //Create a list of all weapons a user has
            var avatarWeapons = db.AvatarUnlocks.Where(x => x.UserId == userId).Where(x => x.Avatar.Type.ToString() == "Weapon").ToList();
            //If the user has no weapons unlocked
            if (avatarWeapons.Count() == 0)
            {
                // Add defualt weapon of each race (ie none) to user's unlocks
                //search the avatars table where the name is none and the type is Weapon
                var noWeaponList = db.Avatars.Where(x => x.Name == "none").Where(x => x.Type == "Weapon").ToList();
                foreach (Avatar wep in noWeaponList)
                {
                    AvatarUnlock adder = new AvatarUnlock();
                    adder.AvaId = wep.AvaId;
                    adder.UserId = userId;
                    db.AvatarUnlocks.Add(adder);
                    db.SaveChanges();
                }
                avatarWeapons = db.AvatarUnlocks.Where(x => x.UserId == userId).Where(x => x.Avatar.Type.ToString() == "Weapon").ToList();
            }

            //Create a list of the avatars to pass
            System.Collections.Generic.List<Avatar> SelectWeapon = new System.Collections.Generic.List<Avatar>();
            foreach (AvatarUnlock avaUnlk in avatarWeapons)
            {
                //Get the current avatar object from the users list based on the avatar id
                Avatar adder = db.Avatars.Where(x => x.AvaId == avaUnlk.AvaId).First();
                //Add that avatar object to the list of avatar objects if we don't have an object of the same name
                if (SelectWeapon.Any(x => x.Name == adder.Name) == false)
                {
                    SelectWeapon.Add(adder);
                    System.Diagnostics.Debug.WriteLine(adder.Name.ToString());
                }
            }

            return View(SelectWeapon);
        }

        //
        // POST: /Manage/SetWeapon
        [HttpPost]
        public ActionResult SetWeapon(string selected_weapon)
        {
            //get the current logged-in user's id
            var userId = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.UserId).FirstOrDefault();

            //update the user selected avatar to the database
            UserAvatar userAvatars = db.UserAvatars.Where(x => x.UserId == userId).Select(x => x).ToList().FirstOrDefault(); //find the user entry in the database table
            // Get the needed avatar based on current race
            Avatar requestAvatarItem = db.Avatars.Where(x => x.Name == selected_weapon).Where(x => x.Race == userAvatars.Race).Where(x => x.Type == "Weapon").FirstOrDefault();

            userAvatars.Weapon= requestAvatarItem.Imagefile; //change their avatar weapon
            db.Entry(userAvatars).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public void GiveUserAvatar(int userId)
        {
            //populate the table with default values
            UserAvatar userAvatarDef = new UserAvatar();

            userAvatarDef.UserId = userId;
            userAvatarDef.Body = "human1.PNG";
            userAvatarDef.Armor = "none.PNG";
            userAvatarDef.Weapon = "none.PNG";
            userAvatarDef.Race = "human";

            //create a new row in the UserAvatars database
            db.UserAvatars.Add(userAvatarDef);
            db.SaveChanges();
        }

        //TEST FUNCTION:: DON'T REMOVE YET - Alex 5-10-19
        //Used to create the default user avatar for a given user id, useful in testing
        public UserAvatar CreateDefaultAvatar(int userId)
        {
            //populate the table with default values
            UserAvatar userAvatars = new UserAvatar();
            userAvatars.UserId = userId;
            userAvatars.Body = "human1.PNG";
            userAvatars.Armor = "none.PNG";
            userAvatars.Weapon = "none.PNG";
            userAvatars.Race = "human";
            return userAvatars;
        }

        //
        // GET: /Manage/ManageLogins
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId());
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }

        //
        // GET: /Manage/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        #endregion
    }
}