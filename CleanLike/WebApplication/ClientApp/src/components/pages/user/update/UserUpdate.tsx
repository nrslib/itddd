import * as React from "react";
import { RouteComponentProps } from "react-router";
import { Link } from "react-router-dom";
import User from "../../../models/users/UserResponse";

interface UserUpdateState {
    id: string;
    currentName: string;
    inputName: string;
}

export class UserUpdate extends React.Component<RouteComponentProps<{ id: string }>, UserUpdateState> {
    constructor(props: RouteComponentProps<{ id: string }>) {
        super(props);

        const id = props.match.params.id;

        this.state = {
            id: id,
            currentName: '',
            inputName: ''
        };

        fetch(`api/User/${id}`)
            .then(res => res.json() as Promise<UserGetResponseModel>)
            .then(data => this.setState({ currentName: data.user.name }));
    }

    public render(): JSX.Element | false | null {
        return (
            <section>
                <h1>User Update</h1>

                <dl className="row">
                    <dt className="col-sm-2">Current Name</dt>
                    <dd className="col-sm-10">{this.state.currentName}</dd>
                </dl>
                <form onSubmit={this.handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="name">Name</label>
                        <input id="name" type="text" value={this.state.inputName} onChange={this.handleNameChange} required />
                    </div>
                    <button type="submit" value="submit" className="btn btn-primary">Submit</button>
                </form>
                <p>
                    <Link className="btn btn-default" to={`/user/detail/${this.state.id}`}>Go back</Link>
                </p>
            </section>
        );
    }

    private handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        if (!this.state.inputName) {
            return;
        }

        const payload = {
            name: this.state.inputName
        };

        fetch(`api/User/${this.props.match.params.id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload),
        })
            .then(_ => {
                this.props.history.push(`/User/detail/${this.props.match.params.id}`);
            });
    };

    private handleNameChange = (e: React.FormEvent<HTMLInputElement>) => {
        this.setState({ inputName: e.currentTarget.value });
    };
}

interface UserGetResponseModel {
    user: User
}