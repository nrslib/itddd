import * as React from "react";
import {RouteComponentProps} from "react-router";
import {Link} from "react-router-dom";

interface UserAddState {
    name: string
}

export class UserAdd extends React.Component<RouteComponentProps<{}>, UserAddState> {
    constructor(props: RouteComponentProps) {
        super(props);

        this.state = {
            name: ''
        };
    }

    public render(): JSX.Element | false | null {
        return (
            <div>
                <h1>User Add</h1>
                <form onSubmit={this.handleSubmit}>
                    <div className="form-group">
                        <input type="text" value={this.state.name} onChange={this.handleNameChange} />
                    </div>
                    <button type="submit" value="Submit" className="btn btn-primary">Submit</button>
                </form>
                <Link className="btn btn-default" to="/user">Go back</Link>
            </div>
        );
    }

    private handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        if(!this.state.name) {
            return;
        }

        const payload = {
            userName: this.state.name
        };

        fetch('api/User', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(payload),
        })
            .then(res => res.json() as Promise<UserAddResponseModel>)
            .then(data => {
                this.props.history.push('/user')
            });
    };

    private handleNameChange = (e: React.FormEvent<HTMLInputElement>) => {
        this.setState({name: e.currentTarget.value});
    };
}

interface UserAddResponseModel {
    createdUserId: string;
}
