import * as React from "react";
import {RouteComponentProps} from "react-router";
import {Link} from "react-router-dom";
import User from "../../../models/users/UserResponse";

interface UserIndexState {
    users: User[];
}

export class UserIndex extends React.Component<RouteComponentProps<{}>, UserIndexState> {
    constructor(props: RouteComponentProps) {
        super(props);

        this.state = {
            users: []
        };

        this.load();
    }

    public render(): JSX.Element | false | null {
        return (
            <div>
                <h1>User Index</h1>
                {this.userList()}
                <Link className="btn btn-primary" to={'/user/add'}>Add User</Link>
            </div>
        );
    }

    private userList() {
        return (
            <table className="table">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Detail</th>
                        <th>Delete</th>
                    </tr>
                </thead>
                <tbody>
                {this.state.users.map(x =>
                    <tr key={x.id}>
                        <td>{x.id}</td>
                        <td><Link className="btn btn-default" to={`/user/detail/${x.id}`}>Detail</Link></td>
                        <td><button className="btn btn-default" onClick={this.handleDeleteButtonClick.bind(this, x.id)}>Delete</button></td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    private load(): Promise<void> {
        return fetch('api/User')
            .then(res => res.json() as Promise<UserIndexResponseModel>)
            .then(data => this.setState({ users: data.users }));
    }


    private handleDeleteButtonClick(id: string) {
        fetch(`api/User/${id}`, { method: 'DELETE' })
            .then(_ => this.load());
    }
}

interface UserIndexResponseModel {
    users: User[];
}
