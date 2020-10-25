import "./App.css";
import React from "react";
import { Component } from "react";
import Layout from "./components/Layout";
import { userContext } from './userContext';
import axios from "axios";

export default class App extends Component {
  static displayName = App.name;

  constructor(props) {
    super(props);
    this.state = {
      user: {}
    };

    this.login = this.login.bind(this);
    this.logout = this.logout.bind(this);
  }

  login() {
    this.props.openIdManager.signinRedirect();
  }

  logout() {
    this.props.openIdManager.signoutRedirect();
  }

  componentDidMount() {
    axios.defaults.baseURL = process.env.REACT_APP_ACCOUNTS_API;
    axios.defaults.headers.common['Authorization'] = '';

    this.props.openIdManager.getUser().then((user) => {
      if (user && !user.expired) {
        this.setState({ user: user });
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + user.access_token;
      }
    });
  }

  render() {

    const value = {
      user: this.state.user,
      loginUser: this.login,
      logoutUser: this.logout
    }

    return (
      <userContext.Provider value={value}>
        <Layout />
      </userContext.Provider>
    )
  };
}