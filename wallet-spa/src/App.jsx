import "./App.css";
import React from "react";
import { Component } from "react";
import Layout from "./components/Layout";

export default class App extends Component {
  static displayName = App.name;
  
  constructor(props) {
    super(props)
  }

  render() {
    return (
      <Layout openIdManager={this.props.openIdManager}/>
    )
  };
}