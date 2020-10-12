import PropTypes from 'prop-types';

import React from "react";
import { Typography } from '@material-ui/core';
import accountsService from "../store/accountsService";
import { withStyles } from "@material-ui/core/styles";
import Paper from '@material-ui/core/Paper';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import PageBase from "../components/PageBase";

import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import Divider from "@material-ui/core/Divider";

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

class Accounts extends React.Component {
  static displayName = Accounts.name;

  constructor(props) {
    super(props);

    this.state = {
      accounts: []
    }

  }
  componentDidMount() {
    this.props.openIdManager.getUser().then((user) => {
      if (user) {
        accountsService
          .getAccounts(user)
          .then((response) => {
            this.setState(response.data);
            console.log(response.data);
          })
          .catch((e) => {
            console.log(e);
          });
      }
    });
  }

  render() {
    return (

      <Card>
        <CardContent>
          <Typography color="textSecondary" gutterBottom>
            Accounts
        </Typography>
          <Divider />
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>Account</TableCell>
                <TableCell>Balance</TableCell>
                <TableCell>Currency</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {
                this.state.accounts.map((account) => {
                  return (
                    <TableRow key={account.accountId}>
                      <TableCell><a className="text-dark" href={`/accounts/${account.accountId}`}>{account.accountId}</a></TableCell>
                      <TableCell>{account.currentBalance}</TableCell>
                      <TableCell>{account.currency}</TableCell>
                    </TableRow>
                  )
                })
              }
            </TableBody>
          </Table>
        </CardContent>
      </Card>

    );
  }
}

export default Accounts;