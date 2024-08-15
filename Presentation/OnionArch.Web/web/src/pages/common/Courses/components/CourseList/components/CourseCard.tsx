import React from 'react'
import { Link } from 'react-router-dom';
//models
import { CourseViewModel } from '../../../../../../models/viewModels/CourseViewModel';
//mui components
import { Box, Card, CardActions, CardContent, CardMedia, Divider, Stack, Typography } from '@mui/material'
//icons
import SubjectIcon from '@mui/icons-material/Subject';
import AccessTimeIcon from '@mui/icons-material/AccessTime';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
//helpers
import { formatDuration } from '../../../../../../utils/TimeSpan';

type CourseCardType = {
    data: CourseViewModel
}

const CourseCard = (props: CourseCardType) => {
    const { id, title, shortDescription, totalLessonDuration, price, teacher, lessons, students } = props.data
    const formattedPrice = price.toFixed(2)
    const formattedTotalLessonDuration = formatDuration(totalLessonDuration)

    return (
        <Link to={`/courses/${id}`} style={{ textDecoration: "none" }}>
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
                    image='https://www.datocms-assets.com/64859/1656365285-ingilizce-a1-a2-egitimi.png?q=70&auto=format&w=650&fit=max&iptc=allow'
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

                    <Stack direction="row" spacing={2} sx={{ marginTop: "0.5rem" }}>
                        <Box sx={{ display: "flex", alignItems: "center", gap: "4px" }}>
                            <SubjectIcon sx={{ fontSize: 16 }} />
                            <Typography variant='caption'>
                                {lessons.length} Lessons
                            </Typography>
                        </Box>

                        <Box sx={{ display: "flex", alignItems: "center", gap: "4px" }}>
                            <AccessTimeIcon sx={{ fontSize: 16 }} />
                            <Typography variant='caption'>
                                {formattedTotalLessonDuration}
                            </Typography>
                        </Box>
                    </Stack>
                </CardContent>

                <Divider variant='middle' />

                <CardActions sx={{ paddingX: "16px" }}>
                    <Box sx={{ width: "100%", display: "flex", justifyContent: "space-between" }}>
                        <Stack direction="row" spacing={0.5} sx={{ alignItems: "center" }}>
                            <AccountCircleIcon sx={{ fontSize: 22 }} />
                            <Typography variant='body2'>
                                {teacher.user.firstName + " " + teacher.user.lastName}
                            </Typography>
                        </Stack>

                        <Typography variant='subtitle2'>
                            {formattedPrice}TL
                        </Typography>
                    </Box>
                </CardActions>
            </Card>
        </Link>
    )
}

export default CourseCard