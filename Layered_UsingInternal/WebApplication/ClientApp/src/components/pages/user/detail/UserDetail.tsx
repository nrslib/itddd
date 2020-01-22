import * as React from "react";
import { RouteComponentProps } from "react-router";
import { Link } from "react-router-dom";
import User from "../../../models/users/UserResponse";

interface UserDetailStatus {
    user: User;
    createCircleName: string;
}

export class UserDetail extends React.Component<RouteComponentProps<{ id: string }>, UserDetailStatus> {

    constructor(props: RouteComponentProps<{id: string}>) {
        super(props);

        const id = props.match.params.id;

        this.state = {
            user: { id: id, name: "" },
            createCircleName: ""
        };

        fetch(`api/User/${id}`)
            .then(res => res.json() as Promise<UserGetResponseModel>)
            .then(data => {
                this.setState({
                    user: {
                        id: id,
                        name: data.user.name
                    }
                });
            });
    }

    public render() {
        return (
            <section>
                <h1>User Detail</h1>

                <section>
                    <h2>Detail</h2>
                    <dl className="row">
                        <dt className="col-sm-2">Id</dt>
                        <dd className="col-sm-10">{this.state.user.id}</dd>

                        <dt className="col-sm-2">Name</dt>
                        <dd className="col-sm-10">{this.state.user.name}</dd>
                    </dl>

                    <p>
                        <Link className="btn btn-primary" to={`/user/update/${this.state.user.id}`}>Update</Link>
                    </p>
                </section>
                
                <section>
                    <h2>Create Circle</h2>
                    <form onSubmit={this.handleSubmit}>
                        <div className="form-group">
                            <label htmlFor="create-circle-name">Circle Name</label>
                            <input id="create-circle-name" type="text" value={this.state.createCircleName} onChange={this.handleNameChange} required />
                        </div>
                        <button type="submit" value="Submit" className="btn btn-primary">Create</button>
                    </form>
                </section>

                <p>
                    <Link className="btn btn-default" to={'/user'}>Go Back</Link>
                </p>
            </section>
        );
    }

    private handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        if (!this.state.createCircleName) {
            return;
        }

        const payload = {
            circleName: this.state.createCircleName,
            ownerId: this.state.user.id,
        };

        fetch('api/Circle', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload),
            })
            .then(res => res.json() as Promise<CirclePostResponseModel>)
            .then(data => {
                this.props.history.push(`/circle/detail/${data.createdCircleId}`)
            });
    };

    private handleNameChange = (e: React.FormEvent<HTMLInputElement>) => {
        this.setState({ createCircleName: e.currentTarget.value });
    };
}

interface UserGetResponseModel {
    user: User;
}

interface CirclePostResponseModel {
    createdCircleId: string;
}