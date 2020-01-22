import * as React from "react";
import {RouteComponentProps} from "react-router";
import Circle from "../../../models/circles/CircleResponse";
import User from "../../../models/users/UserResponse";
import {Link} from "react-router-dom";

interface CircleDetailStatus {
    circle: Circle,
    owner: User,
}

export class CircleDetail extends React.Component<RouteComponentProps<{id: string}>, CircleDetailStatus> {
    constructor(props: RouteComponentProps<{id: string}>) {
        super(props);

        const id = props.match.params.id;

        this.state = {
            circle: { id: id, name: '', ownerId: '', memberIds: [] },
            owner: { id: '', name: '' }
        };

        fetch(`api/Circle/${id}`)
            .then(res => res.json() as Promise<CircleGetResponseModel>)
            .then(data => {
                this.setState({
                    circle: {
                        id: id,
                        name: data.circle.name,
                        ownerId: data.circle.ownerId,
                        memberIds: data.circle.memberIds,
                    },
                    owner: {
                        id: data.owner.id,
                        name: data.owner.name
                    }
                });
            });
    }

    public render() {
        return (
            <section>
                <h1>Circle Detail</h1>

                <section>
                    <h2>Detail</h2>
                    <p>
                        <dl className="row">
                            <dt className="col-sm-2">Id</dt>
                            <dd className="col-sm-10">{this.state.circle.id}</dd>

                            <dt className="col-sm-2">Name</dt>
                            <dd className="col-sm-10">{this.state.circle.name}</dd>

                            <dt className="col-sm-2">Owner</dt>
                            <dd className="col-sm-10">{this.state.owner.name}</dd>
                        </dl>

                        <Link className="btn btn-primary" to={`/circle/update/${this.state.circle.id}`}>Update</Link>
                    </p>
                </section>

                <section>
                    <h2>Members</h2>
                    {this.memberList(this.state.circle.memberIds)}
                    <p>
                        <Link className="btn btn-primary" to={`/circle/member/add/${this.state.circle.id}`}>Add Member</Link>
                    </p>
                </section>
                
                <p>
                    <Link className="btn btn-default" to={'/circle'}>Go Back</Link>
                </p>
            </section>
        );
    }

    private memberList(member: string[]) {
        return (
            <table className="table">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                    </tr>
                </thead>
                <tbody>
                {
                    member.map(x =>
                        <tr key={x}>
                            <td>{x}</td>
                            <td><Link to={`/user/detail/${x}`}>Detail</Link></td>
                        </tr>)
                }
                </tbody>
            </table>
        );
    }
}

interface CircleGetResponseModel {
    circle: Circle;
    owner: User;
}
