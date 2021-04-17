import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

export class Edit extends Component {
    constructor(props) {
        super(props);

        this.onChangeTitle = this.onChangeTitle.bind(this);
        this.onChangeDescription = this.onChangeDescription.bind(this);
        this.onChangeDateStarted = this.onChangeDateStarted.bind(this);
        this.onChangeDateFinished = this.onChangeDateFinished.bind(this);
        this.onSubmit = this.onSubmit.bind(this);

        this.state = {
            title: '',
            description: '',
            dateStarted: null,
            dateFinished: null,
        }
    }

    componentDidMount() {
        const { id } = this.props.match.params;

        axios.get('api/note/' + id).then(note => {
            const response = note.data;
            
            this.setState({
                title: response.title,
                description: response.description,
                dateStarted: response.dateStarted.slice(0, 10),
                dateFinished: response.dateFinished.slice(0, 10)
            });
        });
    }

    onChangeTitle(e) {
        this.setState({
            title: e.target.value
        });
    }

    onChangeDescription(e) {
        this.setState({
            description: e.target.value
        });
    }

    onChangeDateStarted(e) {
        this.setState({
            dateStarted: e.target.value
        });
    }

    onChangeDateFinished(e) {
        this.setState({
            dateFinished: e.target.value
        });
    }

    onSubmit(e) {
        e.preventDefault();
        const { history } = this.props;
        const {id} = this.props.match.params;

        let noteObject = {
            id: id,
            title: this.state.title,
            description: this.state.description,
            dateStarted: this.state.dateStarted,
            dateFinished: this.state.dateFinished
        };

        axios.put('api/note', noteObject).then(result => {
            history.push('/notes');
        });
    }

    render() {
        return (
            <div className="note-form">
                <h3>Add new note</h3>
                <form onSubmit={this.onSubmit}>
                    <div className="form-group">
                        <label>Title</label>
                        <input type="text" className="form-control" value={this.state.title || ''} onChange={this.onChangeTitle} />
                    </div>
                    <div className="form-group">
                        <label>Description</label>
                        <input type="text" className="form-control" value={this.state.description || ''} onChange={this.onChangeDescription} />
                    </div>
                    <div className="row">
                        <div className="col col-md-6 col-sm-6 col-xs-12">
                            <div className="form-group">
                                <label>Date of start:  </label>
                                <input 
                                  type="date" 
                                  className="form-control" 
                                  value={this.state.dateStarted || ''} 
                                  onChange={this.onChangeDateStarted}
                                />
                            </div>
                        </div>
                        <div className="col col-md-6 col-sm-6 col-xs-12">
                          <div className="form-group">
                            <label>Date of finish:  </label>
                            <input 
                                type="date" 
                                className="form-control" 
                                value={this.state.dateFinished || ''} 
                                onChange={this.onChangeDateFinished}
                            />
                            </div>
                        </div>
                    </div>
                    <div className="form-group">
                        <button className="btn btn-primary">Update</button>
                        <br />
                        <Link to="/notes">Return</Link>
                    </div>
                </form>
            </div>
        );
    }
}