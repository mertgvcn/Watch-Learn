import { useParams } from 'react-router-dom'
//mui components
import { Container } from '@mui/material'
import ReactPlayer from 'react-player'

const MyCourseDetailsPage = () => {
    const { id } = useParams()

    const handleProgress = (e: any) => {
        console.log(e)
    }
    return (
        <Container>
            my course id : {id} 
            <ReactPlayer 
                url='"https://www.youtube.com/watch?v=o1chMISeTC0&t=2508s"}'
                width="640px"
                height="480px"
                controls
                onProgress={handleProgress}
            />
        </Container>
    )
}

export default MyCourseDetailsPage