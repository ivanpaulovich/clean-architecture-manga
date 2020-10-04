import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/styles';
import TopMenu from "../components/TopMenu";
import SideMenu from "../components/SideMenu";
import Footer from "../components/Footer";
import MainContent from "../components/MainContent";

const styles = theme => ({
  root: {
    display: 'flex'
  },
});

class Layout extends React.Component {
  static displayName = Layout.name;

  constructor(props) {
    super(props);
  }

  render() {
    const { classes } = this.props;
    return (
      <div className={classes.root}>
        <TopMenu />
        <SideMenu openIdManager={this.props.openIdManager} />
        <MainContent openIdManager={this.props.openIdManager} />
        <Footer />
      </div>
    );
  }
}

Layout.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Layout);