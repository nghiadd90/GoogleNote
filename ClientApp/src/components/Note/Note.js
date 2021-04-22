import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { connect, useSelector } from 'react-redux';
import { getAllNotes } from '../../actions/noteActions';

export class Note extends Component
{
    constructor(props) {
        super(props);

        // this.onDelete = this.onDelete.bind(this);

        this.state = {
            notes: [],
            loading: false
        }
    }

    componentDidMount() {
        this.props.getAllNotes();
    }

    componentDidUpdate(prevProps) {
        if (prevProps.notes.data != this.props.notes.data) {
            this.setState({notes: this.props.notes.data})
        }
    }

    onDelete(id) {
        axios.delete('api/note/' + id).then(result => {
            this.setState((prevState) => {
                return {
                    notes: prevState.notes.filter((item) => item.id !== id)
                }
            });
        });
    }

    renderAllNotes(notes) {
        return (
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Description</th>
                        <th>Date Started</th>
                        <th>Date Finished</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        notes.map(note =>
                        <tr key={note.id}>
                            <td>{note.title}</td>
                            <td>{note.description}</td>
                            <td>{new Date(note.dateStarted).toLocaleDateString()}</td>
                            <td>{note.dateFinished ? new Date(note.dateFinished).toLocaleDateString() : '-'}</td>
                            <td>
                                <Link className="btn btn-primary" to={"notes/edit/" + note.id} >Edit</Link>
                                <br />
                                <button onClick={this.onDelete.bind(this, note.id)} className="btn btn-danger">Delete</button>
                                {/* <button onClick={(e) => this.onDelete(note.id, e)} className="btn btn-danger">Delete</button> */}
                            </td>
                        </tr>
                        )
                    }
                </tbody>
            </table>
        );
    }

    render() {
        let content = this.props.notes.loading ?
        (
            <p>
                <em>Loading...</em>
            </p>
        ) : (
            this.state.notes.length && this.renderAllNotes(this.state.notes)
        );

        return (
            <div>
                <h1>All notes</h1>
                <p>Here you can see all notes</p>
                {content}
            </div>
        );
    }
}

const mapStateToProps = ({notes}) => ({
    notes
});

export default connect(mapStateToProps, { getAllNotes })(Note);

