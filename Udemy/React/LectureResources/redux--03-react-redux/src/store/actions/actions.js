export const INCREMENT = 'INCREMENT';
export const DECREMENT = 'DECREMENT';
export const ADD = 'ADD';
export const SUBTRACT = 'SUBTRACT';
export const STORE_RESULT = 'STORE_RESULT';
export const DELETE_RESULT = 'DELETE_RESULT';

export const increment = () => {
  return {
    type: INCREMENT
  };
};

export const decrement = () => {
  return {
    type: DECREMENT
  };
};

export const add = (value = 1) => {
  return {
    type: ADD,
    val: value
  };
};

export const subtract = (value = 1) => {
  return {
    type: SUBTRACT,
    val: value
  };
};

export const saveResult = (result) => {
  return {
    type: STORE_RESULT,
    result: result
  };
};

export const storeResult = result => {
  return dispatch => {
    setTimeout(() => {
      dispatch(saveResult(result));
    }, 2000);
  }
};

export const deleteResult = id => {
  return {
    type: DELETE_RESULT,
    resultElId: id
  };
};

// Add store result and delete result. See if you can do it without the instructor
// and in such a way that they can handle a payload. Also, add val: for 
// other actions.