import React from "react";
import './App.css'

class App extends React.Component{
  constructor(props){
    super(props)
    this.state = {
      backgroundColor: props.bgColor,
    }
  }
  render(){
    return (
      <h1>app</h1>
    );
  }
}

export default App