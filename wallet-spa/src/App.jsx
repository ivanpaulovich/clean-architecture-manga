import "./App.css";
import React from "react";
import { Route } from "react-router";
import Home from "./pages/Home";
import { AccountUI } from "./components/Account";
import { AuthCallback } from "./pages/AuthCallback";
import { Component } from "react";
import { Container } from 'reactstrap';

export default class App extends Component {
  static displayName = App.name;
  
  constructor(props) {
    super(props)
  }

  render() {
    return (
      <Container>
        <Route
          exact
          path="/"
          render={() => {
            return <Home openIdManager={this.props.openIdManager} />;
          }}
        />
        <Route
          exact
          path="/accounts/:accountId"
          render={() => {
            return <AccountUI />;
          }}
        />
        <Route
          path="/callback"
          render={() => {
            return <AuthCallback />;
          }}
        />

      </Container>
    )
  };
}