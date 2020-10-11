import React, { useState, useEffect } from "react";
import accountsService from "../store/accountsService";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  useParams,
} from "react-router-dom";
import { withStyles } from "@material-ui/core/styles";
import PropTypes from 'prop-types';
import { withRouter } from "react-router";
import Paper from '@material-ui/core/Paper';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import { Typography } from '@material-ui/core';
import Button from '@material-ui/core/Button';
import { Link } from 'react-router-dom';


const styles = theme => ({
  root: {
    display: 'flex'
  },
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

class Account extends React.Component {

  static displayName = Account.name;

  constructor(props) {
    super(props);

    this.state = {
      accountId: this.props.match.params.accountId,
      account: {
        credits: [],
        debits: []
      }
    }

    this.fetchData(this.state.accountId);
  }

  fetchData = id => {
    this.props.openIdManager.getUser().then((user) => {
      if (user) {
        accountsService
          .getAccount(user, id)
          .then((response) => {
            this.setState(response.data);
            console.log(response.data);
          })
          .catch((e) => {
            console.log(e);
          });
      }
    });
  };

  componentDidMount() {

  }

  render() {
    const { classes } = this.props;
    return (
      <main className={classes.fullWidth}>
        <div className={classes.toolbar} />
        <div className={classes.title}>
          <Typography variant='h6'>Account Details</Typography>
        </div>
        <div className={classes.content}>

          <React.Fragment>
            <table className="table table-striped" aria-labelledby="tabelLabel">
              <thead>
                <tr>
                  <th>Account</th>
                  <th>Current Balance</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>
                    {this.state.account.accountId}
                  </td>
                  <td>{this.state.account.currentBalance}</td>
                </tr>
              </tbody>
            </table>

            <table className="table table-striped" aria-labelledby="tabelLabel">
              <thead>
                <tr>
                  <th>Transaction ID</th>
                  <th>Amount</th>
                  <th>Transaction Date</th>
                </tr>
              </thead>
              <tbody>
                {this.state.account.credits && this.state.account.credits.map((credit) => {
                  return <tr>
                    <td>
                      {credit.transactionId}
                    </td>
                    <td>
                      {credit.amount}
                    </td>
                    <td>{credit.transactionDate}</td>
                  </tr>;
                }
                )}
              </tbody>
            </table>


            <table className="table table-striped" aria-labelledby="tabelLabel">
              <thead>
                <tr>
                  <th>Transaction ID</th>
                  <th>Amount</th>
                  <th>Transaction Date</th>
                </tr>
              </thead>
              <tbody>
                {this.state.account.debits && this.state.account.debits.map((debit) => {
                  return <tr>
                    <td>
                      {debit.transactionId}
                    </td>
                    <td>
                      {debit.amount}
                    </td>
                    <td>{debit.transactionDate}</td>
                  </tr>;
                }
                )}
              </tbody>
            </table>

            <Button component={ Link } to={`/accounts/${this.state.accountId}/Deposit`} variant="contained" color="primary">
              Deposit
            </Button>

            <Button component={ Link } to={`/accounts/${this.state.accountId}/Withdraw`} variant="contained" color="primary">
            Withdraw
            </Button>

            <Button component={ Link } to={`/accounts/${this.state.accountId}/Transfer`} variant="contained" color="primary">
            Transfer
            </Button>

            <Button component={ Link } to={`/accounts/${this.state.accountId}/Close`} variant="contained" color="secondary">
            Close
            </Button>

          </React.Fragment>
        </div>
      </main>
    );
  }
}

Account.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(withRouter(Account));
