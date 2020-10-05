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
    const { classes } = this.props;
    return (
      <main className={classes.fullWidth}>
        <div className={classes.toolbar} />
        <div className={classes.title}>
          <Typography variant='h6'>My Accounts</Typography>
        </div>
        <div className={classes.content}>
          <TableContainer component={Paper}>
            <Table className={classes.table} aria-label="simple table">
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
          </TableContainer>
        </div>
      </main>
    );
  }
}

Accounts.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Accounts);