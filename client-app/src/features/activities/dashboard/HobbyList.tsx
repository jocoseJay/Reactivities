import React from 'react';
import { Hobby } from '../../../app/models/hobby';
import { Button, Item, Label, Segment } from 'semantic-ui-react';


interface Props {
    hobbys: Hobby[];
}

export default function HobbyList({ hobbys }: Props) {
    return (
        <Segment>
            <Item.Group divided>
                {hobbys.map(hobby => (

                    <Item key={hobby.id}>
                        <Item.Content>
                            <Item.Header as='a'>{hobby.title}</Item.Header>
                            <Item.Meta>{hobby.date}</Item.Meta>
                            <Item.Description>
                                <div>{hobby.description}</div>
                                <div>{hobby.venue},{hobby.city}</div>
                            </Item.Description>
                            <Item.Extra>
                                <Button floated='right' content='View' color='blue'></Button>
                                <Label content={hobby.category}  />
                            </Item.Extra>
                        </Item.Content>
                    </Item>

                ))}
            </Item.Group>
        </Segment>

    );
}