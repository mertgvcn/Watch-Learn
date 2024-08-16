import { Link } from 'react-router-dom'
//models
import { CurrentStudentCourseViewModel } from '../../../../../../models/viewModels/CurrentStudentCourseViewModel';
//mui components
import { Card, CardMedia, CardContent, Stack, Typography, Box, Divider, CardActions, LinearProgress } from '@mui/material'
//icons
import AccountCircleIcon from '@mui/icons-material/AccountCircle';

type MyCourseCardType = {
    data: CurrentStudentCourseViewModel
}

const MyCourseCard = (props: MyCourseCardType) => {
    const { id, title, shortDescription, imgUrl, teacherName, studentProgressPercentage } = props.data

    return (
        <Link to={`/my-courses/${id}`} style={{ textDecoration: "none" }}>
            <Card
                sx={{
                    height: "fit-content",
                    cursor: "pointer",
                    transition: "transform 0.15s ease-in-out",
                    "&:hover": {
                        transform: "scale(1.02)",
                    }
                }}
            >
                <CardMedia
                    sx={{ height: "160px", objectFit: "cover" }}
                    image={imgUrl}
                />
                
                <CardContent sx={{ display: "flex", flexDirection: "column", justifyContent: "space-between", paddingBottom: "8px" }}>
                    <Stack direction="column" spacing={1} sx={{ height: "120px" }}>
                        <Typography variant='button'>
                            {title}
                        </Typography>
                        <Typography variant='caption'>
                            {shortDescription}
                        </Typography>
                    </Stack>
                </CardContent>

                <Divider variant='middle' sx={{ marginY: "0.5rem" }} />

                <CardActions sx={{ paddingX: "16px" }}>
                    <Box sx={{ width: "100%", display: "flex", flexDirection: "column", gap: "4px" }}>
                        <LinearProgress variant='determinate' value={studentProgressPercentage} />
                        <Typography variant='body2'>%{studentProgressPercentage} Completed</Typography>
                    </Box>
                </CardActions>
            </Card>
        </Link>
    )
}

export default MyCourseCard