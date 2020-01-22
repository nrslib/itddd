import * as React from "react";
import {RouteComponentProps} from "react-router";
import User from "../../../../models/users/UserResponse";
import { Link } from "react-router-dom";

interface CircleMemberAddState {
    id: string;
    users: User[];
}

export class CircleMemberAdd extends React.Component<RouteComponentProps<{id: string}>, CircleMemberAddState> {
    constructor(props: RouteComponentProps<{id: string}>) {
        super(props);

        const id = props.match.params.id;

        this.state = {
            id: id,
            users: []
        };

        const page = 1;
        const size = 10;

        fetch(`api/Circle/${this.state.id}/GetCandidates?page=${page}&size=${size}`)
            .then(res => res.json() as Promise<UserIndexResponseModel>)
            .then(data => {
                this.setState({
                    users: data.users
                });
            });
    }

    public render(): JSX.Element | false | null {
        return (
            <section>
                <h1>Circle Member Add</h1>
                {
                    this.userList()
                }
                <p>
                    <Link className="btn btn-default" to={`/circle/detail/${this.state.id}`}>Go Back</Link>
                </p>
            </section>
        );
    }

    private userList() {
        return (
            <table className="table">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Add</th>
                    </tr>
                </thead>
                <tbody>
                {this.state.users.map(u =>
                    <tr key={u.id}>
                        <td>{u.id}</td>
                        <td>{u.name}</td>
                        <td><button className="btn btn-primary" onClick={this.handleAddMemberButtonClick.bind(this, u.id)}>Add</button></td>
                    </tr>
                )}
                </tbody>
            </table>
            
        );
    }

    private handleAddMemberButtonClick(id: string) {
        const payload = {
            addUserId: id
        };

        fetch(`api/Circle/${this.props.match.params.id}/JoinMember`,
                {
                    method: 'PUT',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(payload),
                }
            )
            .then(_ => {
                this.props.history.push(`/circle/detail/${this.state.id}`);
            });
    }
}

interface UserIndexResponseModel {
    users: User[];
}
