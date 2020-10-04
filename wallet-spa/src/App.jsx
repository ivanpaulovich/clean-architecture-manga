import "./App.css";
import React from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import Home from "./pages/Home";
import { AccountUI } from "./components/Account";
import { AuthCallback } from "./pages/AuthCallback";
import { Component } from "react";

export default class App extends Component {
  static displayName = App.name;
  
  constructor(props) {
    super(props)
  }

  render() {
    return (
      <Layout>
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

      </Layout>
    )
  };
}