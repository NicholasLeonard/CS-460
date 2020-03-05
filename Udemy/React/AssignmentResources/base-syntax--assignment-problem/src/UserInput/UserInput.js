import React from 'react';

const userInput = props => {
  return (
    <div>
      <input type="text" onChange={props.changeUserName} value={props.userName} style={props.style} />
    </div>
  );
};

export default userInput;