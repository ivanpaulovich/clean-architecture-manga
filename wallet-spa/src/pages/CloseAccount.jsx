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

class CloseAccount extends React.Component {

  static displayName = CloseAccount.name;

  constructor(props) {
    super(props);

    this.state = {
      accountId: this.props.match.params.accountId,
      submitted: false
    }

    this.handleInputChange = this.handleInputChange.bind(this);
    this.saveCloseAccount = this.saveCloseAccount.bind(this);
    this.newCloseAccount = this.newCloseAccount.bind(this);
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

  saveCloseAccount = () => {
    this.props.openIdManager.getUser().then((user) => {
      if (user) {
        accountsService
          .closeAccount(user, this.state.accountId)
          .then(response => {
            this.setState({
              accountId: response.data.accountId,
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

  newCloseAccount = () => {
    this.setState({
      accountId: this.props.match.params.accountId,
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
          <Typography variant='h6'>Close Account</Typography>
        </div>
        <div className={classes.content}>

          <div className="submit-form">
            {this.submitted ? (
              <div>
                <h4>You submitted successfully!</h4>
                <button className="btn btn-success" onClick={this.newCloseAccount}>
                  Add
            </button>
              </div>
            ) : (
                <div>
                  <button onClick={this.saveCloseAccount} className="btn btn-success">
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

CloseAccount.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(withRouter(CloseAccount));