import React, {  } from "react";
import accountsService from "../store/accountsService";
import { withRouter } from "react-router";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import { Typography } from '@material-ui/core';
import Button from '@material-ui/core/Button';
import { Link } from 'react-router-dom';
import { grey } from "@material-ui/core/colors";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import Divider from "@material-ui/core/Divider";

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
    accountsService
      .getAccount(id)
      .then((response) => {
        this.setState(response.data);
        console.log(response.data);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  componentDidMount() {

  }

  render() {

    const styles = {
      toggleDiv: {
        marginTop: 20,
        marginBottom: 5
      },
      toggleLabel: {
        color: grey[400],
        fontWeight: 100
      },
      buttons: {
        marginTop: 30,
        float: "right"
      },
      saveButton: {
        marginLeft: 5
      }
    };

    return (

      <React.Fragment>
        <Card>
          <CardContent>
            <Typography color="textSecondary" gutterBottom>
              Account Summary
        </Typography>
            <Divider />


            <Table>
              <TableHead>
                <TableRow>
                  <TableCell>Account</TableCell>
                  <TableCell>Current Balance</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                <TableRow>
                  <TableCell>{this.state.account.accountId}</TableCell>
                  <TableCell>{this.state.account.currentBalance}</TableCell>
                </TableRow>
              </TableBody>
            </Table>

          </CardContent>
        </Card>


        <Card>
          <CardContent>
            <Typography color="textSecondary" gutterBottom>
              Credits
        </Typography>
            <Divider />

            <Table>
              <TableHead>
                <TableRow>
                  <TableCell>Transaction ID</TableCell>
                  <TableCell>Amount</TableCell>
                  <TableCell>Transaction Date</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>

                {this.state.account.credits && this.state.account.credits.map((credit) => {
                  return <TableRow>
                    <TableCell>{credit.transactionId}</TableCell>
                    <TableCell>{credit.amount}</TableCell>
                    <TableCell>{credit.transactionDate}</TableCell>
                  </TableRow>;
                }
                )}
              </TableBody>
            </Table>

          </CardContent>
        </Card>

        <Card>
          <CardContent>
            <Typography color="textSecondary" gutterBottom>
              Debits
            </Typography>
            <Divider />

            <Table>
              <TableHead>
                <TableRow>
                  <TableCell>Transaction ID</TableCell>
                  <TableCell>Amount</TableCell>
                  <TableCell>Transaction Date</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>

                {this.state.account.debits && this.state.account.debits.map((debit) => {
                  return <TableRow>
                    <TableCell>{debit.transactionId}</TableCell>
                    <TableCell>{debit.amount}</TableCell>
                    <TableCell>{debit.transactionDate}</TableCell>
                  </TableRow>;
                }
                )}
              </TableBody>
            </Table>

          </CardContent>
        </Card>

        <div style={styles.buttons}>

          <Button component={Link} to={`/dashboard/accounts/${this.state.accountId}/Deposit`} variant="contained" color="primary">
            Deposit
            </Button>

          <Button component={Link} to={`/dashboard/accounts/${this.state.accountId}/Withdraw`} variant="contained" color="primary">
            Withdraw
            </Button>

          <Button component={Link} to={`/dashboard/accounts/${this.state.accountId}/Transfer`} variant="contained" color="primary">
            Transfer
            </Button>

          <Button component={Link} to={`/dashboard/accounts/${this.state.accountId}/Close`} variant="contained" color="secondary">
            Close
            </Button>

        </div>

      </React.Fragment>
    );
  }
}

export default withRouter(Account);
