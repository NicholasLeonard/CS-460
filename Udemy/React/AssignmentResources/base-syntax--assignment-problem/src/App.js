import React, { Component } from 'react';
import UserOutput from './UserOutput/UserOutput';
import UserInput from './UserInput/UserInput';

import './App.css';

class App extends Component {
  state = {
    userName: 'Hustus'
  };

  changeUserNameHandler = event => {
    this.setState({ userName: event.target.value });
  };

  render() {
    const style = {
      backgroundColor: 'black',
      color: 'white'
    };

    return (
      <div className="App">
        <UserOutput userName={this.state.userName}></UserOutput>
        <UserOutput></UserOutput>
        <UserOutput></UserOutput>
        <UserInput
          style={style}
          userName={this.state.userName}
          changeUserName={this.changeUserNameHandler}></UserInput>

      </div>
    );
  };
}

export default App;
