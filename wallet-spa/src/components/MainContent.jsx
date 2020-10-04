import React, { Component } from "react";
import { makeStyles } from '@material-ui/core/styles';
import { Grid } from '@material-ui/core';
import { Typography } from '@material-ui/core';
import accountsService from "../store/accountsService";
import { withStyles } from "@material-ui/core/styles";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  useParams,
} from "react-router-dom";
import Paper from '@material-ui/core/Paper';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';

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
          <Typography variant='h6'>Title</Typography>
        </div>
        <div className={classes.content}>
          <Typography paragraph>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc maximus,
            nulla ut commodo sagittis, sapien dui mattis dui, non pulvinar lorem
            felis nec erat
          </Typography>

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
                        <TableCell><a className="text-dark" href={`/transactions/${account.accountId}`}>{account.accountId}</a></TableCell>
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
    )
  }


}

export default withStyles(styles, { withTheme: true })(MainContent);