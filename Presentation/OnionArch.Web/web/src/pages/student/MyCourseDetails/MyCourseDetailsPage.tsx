import { useParams } from 'react-router-dom'
//mui components
import { Container } from '@mui/material'

const MyCourseDetailsPage = () => {
    const { id } = useParams()
    return (
        <Container>
            my course id : {id} 
        </Container>
    )
}

export default MyCourseDetailsPage