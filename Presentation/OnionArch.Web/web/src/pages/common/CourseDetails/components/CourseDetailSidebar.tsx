import { useState, useEffect } from 'react';
//mui components
import styled from '@emotion/styled';
import { Box, Button, Divider, Paper, Stack, Typography } from '@mui/material'
//icons
import SubjectIcon from '@mui/icons-material/Subject';
import GroupIcon from '@mui/icons-material/Group';
import AccessTimeIcon from '@mui/icons-material/AccessTime';
//models
import { CourseViewModel } from '../../../../models/viewModels/CourseViewModel';
//helpers
import { formatDuration } from '../../../../utils/TimeSpan';

type CourseDetailSidebarType = {
    course: CourseViewModel
}

const CourseDetailSidebar = ({ course }: CourseDetailSidebarType) => {
    const formattedPrice = course.price.toFixed(2)
    const formattedTotalLessonDuration = formatDuration(course.totalLessonDuration)

    const [isFixedSidebar, setIsFixedSidebar] = useState(false);

    useEffect(() => {
        const onScroll = () => setIsFixedSidebar(window.scrollY >= 300);

        window.removeEventListener('scroll', onScroll);
        window.addEventListener('scroll', onScroll, { passive: true });
        return () => window.removeEventListener('scroll', onScroll);
    }, []);

    return (
        <Paper variant='outlined' sx={{
            width: "300px",
            height: "100%",
            position: "sticky",
            top: 84,
            transform: isFixedSidebar ? "" : "translateY(-300px)"
        }}>
            <Box sx={{
                width: "100%",
                height: "fit-content",
            }}>

                {/* Bu kısma img yerine tanıtım videosu gelecek */}
                <Box sx={{
                    width: "300px",
                    height: "200px",
                    padding: "1px",
                    boxSizing: "border-box",
                    borderTopLeftRadius: "4px",
                    borderTopRightRadius: "4px"
                }}>
                    <img src={require("../../../../assets/images/video_overview.png")} alt="" style={{
                        width: "100%",
                        height: "100%",
                        objectFit: "cover",
                        borderTopLeftRadius: "4px",
                        borderTopRightRadius: "4px"
                    }} />
                </Box>

                <Stack direction="column" spacing={2} sx={{
                    display: "flex",
                    justifyContent: "center",
                    padding: "1rem",
                    boxSizing: "border-box"
                }}>
                    <Stack direction="column" spacing={1} >
                        <Typography variant='h6'>{formattedPrice}TL</Typography>
                        <Button variant='contained'>Buy</Button>
                    </Stack>

                    <Divider />

                    <Stack direction="column" spacing={1}>
                        <StatBox>
                            <IconTextBox>
                                <SubjectIcon sx={{ fontSize: 18 }} />
                                <Typography variant='body1'>
                                    Lessons
                                </Typography>
                            </IconTextBox>
                            <Typography variant='body1'>{course.lessons.length}</Typography>
                        </StatBox>

                        <StatBox>
                            <IconTextBox>
                                <GroupIcon sx={{ fontSize: 18 }} />
                                <Typography variant='body1'>
                                    Attendees
                                </Typography>
                            </IconTextBox>
                            <Typography variant='body1'>{course.students.length}</Typography>
                        </StatBox>

                        <StatBox>
                            <IconTextBox>
                                <AccessTimeIcon sx={{ fontSize: 18 }} />
                                <Typography variant='body1'>
                                    Total Duration
                                </Typography>
                            </IconTextBox>
                            <Typography variant='body1'>{formattedTotalLessonDuration}</Typography>
                        </StatBox>
                    </Stack>
                </Stack>

            </Box>
        </Paper>
    )
}

export default CourseDetailSidebar

const StatBox = styled(Box)({
    display: "flex",
    alignItems: "center",
    justifyContent: "space-between"
})

const IconTextBox = styled(Box)({
    display: "flex",
    alignItems: "center",
    gap: "8px"
})