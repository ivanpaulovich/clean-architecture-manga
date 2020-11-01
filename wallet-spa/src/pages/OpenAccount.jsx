import React, { } from "react";
import accountsService from "../store/accountsService";
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

class OpenAccount extends React.Component {

  static displayName = OpenAccount.name;

  constructor(props) {
    super(props);

    this.state = {
      id: null,
      amount: "",
      currency: "",
      submitted: false
    }

    this.handleInputChange = this.handleInputChange.bind(this);
    this.saveAccount = this.saveAccount.bind(this);
    this.newAccount = this.newAccount.bind(this);
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

  saveAccount = () => {
    var bodyFormData = new FormData();
    bodyFormData.append('amount', this.state.amount);
    bodyFormData.append('currency', this.state.currency);

    accountsService
      .openAccount(bodyFormData)
      .then(response => {
        this.setState({
          id: response.data.account.accountId,
          title: response.data.account.accountId,
          description: response.data.account.accountId,
          submitted: true
        });
      })
      .catch(e => {
        console.log(e);
      });
  };

  newAccount = () => {
    this.setState({
      id: null,
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

      <PageBase title="Open a New Account" navigation="My Accounts / Open a New Account">

        {this.state.submitted ? (
          <Redirect to={`/dashboard`} push />
        )  : (
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
                  onClick={this.saveAccount}
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

export default withRouter(OpenAccount);