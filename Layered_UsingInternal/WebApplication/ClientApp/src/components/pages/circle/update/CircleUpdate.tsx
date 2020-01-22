import * as React from "react";
import {RouteComponentProps} from "react-router";
import {Link} from "react-router-dom";
import Circle from "../../../models/circles/CircleResponse";

interface CircleUpdateState {
    id: string,
    currentName: string;
    inputName: string;
}

export class CircleUpdate extends React.Component<RouteComponentProps<{id: string}>, CircleUpdateState> {
    constructor(props: RouteComponentProps<{id: string}>) {
        super(props);

        const id = props.match.params.id;

        this.state = {
            id: id,
            currentName: '',
            inputName: ''
        };

        fetch(`api/Circle/${id}`)
            .then(res => res.json() as Promise<CircleDetailResponseModel>)
            .then(data => this.setState({ currentName: data.circle.name }));
    }

    public render(): JSX.Element | false | null {
        return (
            <div>
                <h1>Circle Update</h1>
                <p>Current Name: {this.state.currentName}</p>
                <form onSubmit={this.handleSubmit}>
                    <input type="text" value={this.state.inputName} onChange={this.handleNameChange}/>
                    <input type="submit" value="submit"/>
                </form>
                <Link className="btn btn-default" to={`/circle/detail/${this.state.id}`}>Go back</Link>
            </div>
        );
    }

    private handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        if(!this.state.inputName) {
            return;
        }

        const payload = {
            name: this.state.inputName
        };

        fetch(`api/Circle/${this.props.match.params.id}`, {
            method: 'PUT',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(payload),
        })
            .then(_ => {
                this.props.history.push(`/circle/detail/${this.props.match.params.id}`);
            });
    };

    private handleNameChange = (e: React.FormEvent<HTMLInputElement>) => {
        this.setState({inputName: e.currentTarget.value});
    };
}

interface CircleDetailResponseModel {
    circle: Circle
}