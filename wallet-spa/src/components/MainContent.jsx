import React, { Component } from "react";
import { withStyles } from "@material-ui/core/styles";
import {
  Route,
} from "react-router-dom";
import { Container } from 'reactstrap';
import Accounts from "../pages/Accounts";
import Account from "../pages/Account";
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

  render() {
    return (
      <Container>
          <Route exact={true} path="/dashboard/openaccount" component={OpenAccount} />
          <Route exact={true} path="/dashboard/accounts/:accountId/close" component={CloseAccount} />
          <Route exact={true} path="/dashboard/accounts/:accountId/transfer" component={Transfer} />
          <Route exact={true} path="/dashboard/accounts/:accountId/deposit" component={Deposit} />
          <Route exact={true} path="/dashboard/accounts/:accountId/withdraw" component={Withdraw} />
          <Route exact={true} path="/dashboard/accounts/:accountId" component={Account} />
          <Route exact={true} path="/dashboard" component={Accounts} />
        </Container>
    )
  }
}

export default withStyles(styles, { withTheme: true })(MainContent);