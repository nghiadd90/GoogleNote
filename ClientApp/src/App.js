import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';

import './custom.css'
import Note from './components/Note/Note';
import { Create, Edit } from './components/Note/index';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/notes' component={Note} />
        <Route path='/notes/create' component={Create} />
        <Route path='/notes/edit/:id' component={Edit} />
      </Layout>
    );
  }
}
