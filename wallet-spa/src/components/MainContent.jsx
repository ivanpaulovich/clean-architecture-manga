import React, { Component } from "react";
import { withStyles } from "@material-ui/core/styles";
import {
  Route,
} from "react-router-dom";
import { Container } from 'reactstrap';
import Accounts from "../pages/Accounts";
import Account from "../pages/Account";
import { AuthCallback } from "../pages/AuthCallback";
import OpenAccount from "../pages/OpenAccount";
import Deposit from "../pages/Deposit";
import Withdraw from "../pages/Withdraw";
import Transfer from "../pages/Transfer";
import CloseAccount from "../pages/CloseAccount";

const styles = theme => ({
  toolbar: theme.mixins.toolbar,
  title: {
    flexGrow: 1,
    backgroundColor: theme.palette.background.default,
    padding: theme.spacing(3),
  },
  content: {
    flexGrow: 1,
    padding: theme.spacing(3),
  },
  fullWidth: {
    width: '100%',
  },
  root: {
    flexGrow: 1,
  },
  paper: {
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary,
  },
  table: {
    minWidth: 650,
  },
});

class MainContent extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <Container>
          <Route
            exact
            path="/OpenAccount"
            render={() => {
              return <OpenAccount />;
            }}
          />
          <Route
            exact
            path="/"
            render={() => {
              return <Accounts />;
            }}
          />
          <Route
            exact
            path="/accounts/:accountId/close"
            render={() => {
              return <CloseAccount />;
            }}
          />
          <Route
            exact
            path="/accounts/:accountId/transfer"
            render={() => {
              return <Transfer />;
            }}
          />
          <Route
            exact
            path="/accounts/:accountId/deposit"
            render={() => {
              return <Deposit />;
            }}
          />
          <Route
            exact
            path="/accounts/:accountId/withdraw"
            render={() => {
              return <Withdraw />;
            }}
          />
          <Route
            exact
            path="/accounts/:accountId"
            render={() => {
              return <Account />;
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
  }
}

export default withStyles(styles, { withTheme: true })(MainContent);