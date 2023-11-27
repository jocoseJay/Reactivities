import { useEffect, useState } from 'react'
import './styles.css'
import axios from 'axios';
import 'semantic-ui-css/semantic.min.css'
import { Container, Header, List } from 'semantic-ui-react';
import { Hobby } from '../models/hobby';
import NavBar from './NavBar';
import DisplayHobbyDashBoard from '../../features/activities/dashboard/ActivitiesDashBoard';

function App() {

  const [activities, setActivities] = useState<Hobby[]>([]);

  useEffect(() =>{
         axios.get<Hobby[]>('http://localhost:5000/api/activities')
         .then(response => {
          setActivities(response.data);
         });
  }, []);

  return (
    <>
      <NavBar/>
      <Container style={{marginTop:"7em"}}>
     <DisplayHobbyDashBoard hobbies = {activities} />
      </Container>
        
    </>
  )
}

export default App
