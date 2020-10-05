import React, { } from "react";
import accountsService from "../store/accountsService";
import { withStyles } from "@material-ui/core/styles";
import PropTypes from 'prop-types';
import { withRouter } from "react-router";
import { Typography } from '@material-ui/core';

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
      prevState => {
        return { 
          [name]: value 
        };
      })
  };

  saveAccount = () => {
    this.props.openIdManager.getUser().then((user) => {
      if (user) {
        var bodyFormData = new FormData();
        bodyFormData.append('amount', this.state.amount);
        bodyFormData.append('currency', this.state.currency);

        accountsService
          .openAccount(user, bodyFormData)
          .then(response => {
            this.setState({
              id: response.data.account.accountId,
              title: response.data.account.accountId,
              description: response.data.account.accountId
            });
            this.setSubmitted(true);
            console.log(response.data);
          })
          .catch(e => {
            console.log(e);
          });
      }
    })
  };

  newAccount = () => {
    this.setAccount({
      id: null,
      amount: "",
      currency: "",
      submitted: false
    });
    this.setSubmitted(false);
  };

  render() {

    const { classes } = this.props;

    return (

      <main className={classes.fullWidth}>
        <div className={classes.toolbar} />
        <div className={classes.title}>
          <Typography variant='h6'>My Accounts</Typography>
        </div>
        <div className={classes.content}>

          <div className="submit-form">
            {this.submitted ? (
              <div>
                <h4>You submitted successfully!</h4>
                <button className="btn btn-success" onClick={this.newAccount}>
                  Add
            </button>
              </div>
            ) : (
                <div>
                  <div className="form-group">
                    <label htmlFor="amount">Amount</label>
                    <input
                      type="text"
                      className="form-control"
                      id="amount"
                      required
                      value={this.state.amount}
                      onChange={this.handleInputChange}
                      name="amount"
                    />
                  </div>

                  <div className="form-group">
                    <label htmlFor="currency">Currency</label>
                    <input
                      type="text"
                      className="form-control"
                      id="currency"
                      required
                      value={this.state.currency}
                      onChange={this.handleInputChange}
                      name="currency"
                    />
                  </div>

                  <button onClick={this.saveAccount} className="btn btn-success">
                    Submit
            </button>
                </div>
              )}
          </div>



        </div>
      </main>

    );
  }
}

OpenAccount.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(withRouter(OpenAccount));