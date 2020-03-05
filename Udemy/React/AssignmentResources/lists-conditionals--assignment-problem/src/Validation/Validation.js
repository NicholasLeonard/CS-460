import React from 'react';

const validation = props => {
  let valdiationMessage = 'Text long enough!';

  if (props.inputLength < 5) {
    valdiationMessage = 'Text too short!';
  }

  return (
    <div>
      <p>{valdiationMessage}</p>
    </div>
  );
};

export default validation;