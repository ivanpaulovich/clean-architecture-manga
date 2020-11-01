import React, { } from "react";
import transactionService from "../store/transactionService";
import { withRouter } from "react-router";
import PageBase from "../components/PageBase";
import { Link } from "react-router-dom";
import Button from "@material-ui/core/Button";
import MenuItem from "@material-ui/core/MenuItem";
import TextField from "@material-ui/core/TextField";
import Select from "@material-ui/core/Select";
import { grey } from "@material-ui/core/colors";
import FormControl from "@material-ui/core/FormControl";
import InputLabel from "@material-ui/core/InputLabel";
import {Redirect} from "react-router-dom";

class Deposit extends React.Component {

  static displayName = Deposit.name;

  constructor(props) {
    super(props);

    this.state = {
      accountId: this.props.match.params.accountId,
      transactionId: "",
      transactionDate: "",
      amount: "",
      currency: "",
      submitted: false
    }

    this.handleInputChange = this.handleInputChange.bind(this);
    this.saveDeposit = this.saveDeposit.bind(this);
    this.newDeposit = this.newDeposit.bind(this);
  }

  handleInputChange = event => {
    const { name, value } = event.target;
    this.setState(
      () => {
        return {
          [name]: value
        };
      })
  };

  saveDeposit = () => {
    var bodyFormData = new FormData();
    bodyFormData.append('amount', this.state.amount);
    bodyFormData.append('currency', this.state.currency);

    transactionService
      .deposit(this.state.accountId, bodyFormData)
      .then(response => {
        this.setState({
          transactionId: response.data.transaction.transactionId,
          transactionDate: response.data.transaction.transactionDate,
          submitted: true
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };

  newDeposit = () => {
    this.setState({
      accountId: this.props.match.params.accountId,
      transactionId: "",
      transactionDate: "",
      amount: "",
      currency: "",
      submitted: false
    });
  };

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

      <PageBase title="Deposit" navigation="My Accounts / Deposit">

        {this.state.submitted ? (
          <Redirect to={`/dashboard/accounts/${this.state.accountId}`} push />
        ) : (
            <div>

              <TextField
                hintText="Amount"
                label="Amount"
                fullWidth={true}
                margin="normal"
                value={this.state.amount}
                onChange={this.handleInputChange}
                name="amount"
                id="amount"
                required
              />

              <FormControl fullWidth={true}>
                <InputLabel htmlFor="Currency">Currency</InputLabel>
                <Select
                  fullWidth={true}
                  margin="normal"
                  value={this.state.currency}
                  onChange={this.handleInputChange}
                  id="currency"
                  name="currency"
                  required
                >
                  <MenuItem value={"USD"}>USD</MenuItem>
                  <MenuItem value={"EUR"}>EUR</MenuItem>
                  <MenuItem value={"SEK"}>SEK</MenuItem>
                </Select>
              </FormControl>

              <div style={styles.buttons}>
                <Link to="/">
                  <Button variant="contained">Cancel</Button>
                </Link>

                <Button
                  style={styles.saveButton}
                  variant="contained"
                  type="submit"
                  color="primary"
                  onClick={this.saveDeposit}
                >
                  Save
                      </Button>
              </div>

            </div>
          )}


      </PageBase>
    );
  }
}

export default withRouter(Deposit);