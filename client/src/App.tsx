import { useState, useEffect } from "react"
import { ListItemText, Typography } from "@mui/material"
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import axios from "axios"

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);
  useEffect(() => {
    axios.get("https://localhost:5001/api/activities")
    .then((response) => {setActivities(response.data)})
    return () => {}
  }, [])

  return (
    <>
      <Typography variant='h3'>Reactivities</Typography>
      <List>
        {activities.map((activity) => (
          <ListItem key={activity.id}>
            <ListItemText>{activity.title}</ListItemText></ListItem>
        ))}
      </List>
    </>
    
  )
}

export default App
