import React from "react";
import { Button, Container, Menu } from "semantic-ui-react";

export default function CreateNavbar()
{
      return (

        <Menu inverted  fixed="top">
           <Container>
           <Menu.Item header>
            <img src="/assets/logo.png" alt="logo" style={{marginRight : '10px'}}/>
            HobbyLists
           </Menu.Item>
          <Menu.Item name="Hobbys"></Menu.Item>
          <Menu.Item>
            <Button positive content="Create Hobby"/>
          </Menu.Item>

           </Container>
        </Menu>
      )
}