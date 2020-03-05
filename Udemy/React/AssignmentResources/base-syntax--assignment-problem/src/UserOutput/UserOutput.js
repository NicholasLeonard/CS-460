import React, { Component } from 'react';
import './UserOutput.css';

class UserOutput extends Component {

  render() {
    return (
      <div>
        <p>Welcome to the user output paragraph 1</p>
        <p>What about user output paragraph 2? By {this.props.userName}</p>
      </div>
    );
  }
}

export default UserOutput;