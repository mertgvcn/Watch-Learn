import { Link } from 'react-router-dom'
//models
import { CourseViewModel } from '../../../../../../models/viewModels/CourseViewModel'
//mui components
import { Card, CardMedia, CardContent, Stack, Typography, Box, Divider, CardActions, LinearProgress } from '@mui/material'
//icons
import AccountCircleIcon from '@mui/icons-material/AccountCircle';

type MyCourseCardType = {
    data: CourseViewModel
}

const MyCourseCard = (props: MyCourseCardType) => {
    const { id, title, shortDescription, teacher } = props.data
    const studentCourseProgress = Number((Math.random() * 100).toFixed(0))

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
                    image='https://www.datocms-assets.com/64859/1648564414-hafiza-teknikleri.jpg?q=70&auto=format&w=650&fit=max&iptc=allow'
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
                        <LinearProgress variant='determinate' value={studentCourseProgress} />
                        <Typography variant='body2'>%{studentCourseProgress} Completed</Typography>
                    </Box>
                </CardActions>
            </Card>
        </Link>
    )
}

export default MyCourseCard