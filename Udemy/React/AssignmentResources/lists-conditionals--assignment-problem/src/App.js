import React, { Component } from 'react';
import './App.css';
import Validation from './Validation/Validation';
import Char from './Char/Char';


class App extends Component {
  state = {
    inputText: ''
  };

  inputLengthHandler = event => {
    this.setState({
      inputText: event.target.value
    });
  }

  deleteCharHandler = index => {
    const text = this.state.inputText.split('');
    text.splice(index, 1);
    const updatedText = text.join('');
    this.setState({ inputText: updatedText })
  }

  render() {
    const charList = this.state.inputText.split('').map((ch, index) => {
      return <Char letter={ch} key={index} clicked={() => this.deleteCharHandler(index)} />
    });

    return (
      <div className="App">
        <ol>
          <li>When you click a CharComponent, it should be removed from the entered text.</li>
        </ol>
        <p>Hint: Keep in mind that JavaScript strings are basically arrays!</p>

        <input type='text' value={this.state.inputText} onChange={this.inputLengthHandler} />
        <p>{this.state.inputText}</p>
        <Validation inputLength={this.state.inputText.length} />
        {charList}
      </div>
    );
  }
}

export default App;
