import logo from './logo.svg';
import './App.css';
import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { AccountUI } from './components/Account';
import { AuthCallback } from "./components/AuthCallback";

export default class App extends Component {
  static displayName = App.name;

  constructor(props) {
      super(props);
  }

  render() {
      return (
          <Layout>
              <Route exact path='/' render={() => {
                  return <Home openIdManager={this.props.openIdManager} />
              }} />
              <Route exact path='/accounts/:accountId' render={() => {
                  return <AccountUI openIdManager={this.props.openIdManager} />
              }} />
              <Route path='/callback' render={() => {
                  return <AuthCallback />
              }} />
          </Layout>
      );
  }
}

