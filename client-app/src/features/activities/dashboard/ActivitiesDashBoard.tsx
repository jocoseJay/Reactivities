import React from "react";
import { Grid, List } from "semantic-ui-react";
import { Hobby } from "../../../app/models/hobby";
import HobbyList from "./HobbyList";

interface Props {
    hobbies: Hobby[];
}

export default function DisplayHobbyDashBoard({ hobbies }: Props) {
    return (

        <Grid >
            <Grid.Column width='10'>
                
                   <HobbyList hobbys={hobbies} />
               
            </Grid.Column>
        </Grid>
    );
}