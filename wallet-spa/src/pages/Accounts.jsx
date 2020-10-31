
import React from "react";
import { Typography } from '@material-ui/core';
import accountsService from "../store/accountsService";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import Divider from "@material-ui/core/Divider";

class Accounts extends React.Component {
  static displayName = Accounts.name;

  constructor(props) {
    super(props);

    this.state = {
      accounts: []
    }
  }
  
  componentDidMount() {
    accountsService
      .getAccounts()
      .then((response) => {
        this.setState(response.data);
        console.log(response.data);
      })
      .catch((e) => {
        console.log(e);
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
                      <TableCell><a className="text-dark" href={`/dashboard/accounts/${account.accountId}`}>{account.accountId}</a></TableCell>
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