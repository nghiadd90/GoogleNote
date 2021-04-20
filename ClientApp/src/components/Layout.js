import React, { Component } from 'react';
import AppBar  from './appbar/AppBar';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <AppBar />
        <div>
          {this.props.children}
        </div>
      </div>
    );
  }
}
