import React from "react";
import { Grid, List } from "semantic-ui-react";
import { Hobby } from "../../../app/models/hobby";
import HobbyList from "./HobbyList";
import HobbyDetails from "../details/HobbyDetails";

interface Props {
    hobbies: Hobby[];
}

export default function DisplayHobbyDashBoard({ hobbies }: Props) {
    return (
            
        <Grid >
            <Grid.Column width='10'>

                <HobbyList hobbys={hobbies} />

            </Grid.Column>

            <Grid.Column width='6'>
                
                { hobbies[0] &&
                    <HobbyDetails hobby={hobbies[0]} />
                }
            </Grid.Column>
        </Grid>
    );
}