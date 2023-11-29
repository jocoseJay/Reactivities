import React from "react";
import { Hobby } from "../../../app/models/hobby";
import { Button, ButtonGroup, Card, Icon, Image } from "semantic-ui-react";


interface Props{

    hobby : Hobby;
}

export default function HobbyDetails({hobby} : Props)
{
    return(
        <Card fluid>
        <Image src={`/assets/categoryImages/${hobby.category}.jpg`} />
        <Card.Content>
          <Card.Header>{hobby.title}</Card.Header>
          <Card.Meta>
            <span>{hobby.date}</span>
          </Card.Meta>
          <Card.Description>
           {hobby.description}
          </Card.Description>
        </Card.Content>
        <Card.Content extra>
         <ButtonGroup widths='2'>
            <Button basic  content="Edit" color='blue'></Button>
            <Button basic  content="Cancel" color="grey" ></Button>
         </ButtonGroup>
        </Card.Content>
      </Card>
    );
}