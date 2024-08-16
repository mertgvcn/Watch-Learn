import { useState } from 'react';
//models
import { LessonDTO } from '../../../../../models/DTOs/LessonDTO';
import { CourseCommentDTO } from '../../../../../models/DTOs/CourseCommentDTO';
//mui components
import { Box, Paper, Tab, Tabs } from '@mui/material'
//components
import Overview from './tabs/Overview';
import Syllabus from './tabs/Syllabus';
import Comments from './tabs/Comments';

type CourseDetailContentType = {
    description: string,
    lessons: LessonDTO[],
    comments: CourseCommentDTO[]
}

const CourseDetailContent = ({ description, lessons, comments }: CourseDetailContentType) => {
    const [tab, setTab] = useState(0)

    return (
        <Paper variant='outlined' sx={{
            minHeight: "1200px",
            flexGrow: 1,
        }}>

            {/* Tabs */}
            <Box sx={{
                width: '100%',
                typography: 'body1'
            }}>
                <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
                    <Tabs value={tab} onChange={(e, value) => { setTab(value) }}>
                        <Tab label="Overview" value={0} />
                        <Tab label="Syllabus" value={1} />
                        <Tab label="Comments" value={2} />
                    </Tabs>
                </Box>
            </Box>

            <Box sx={{
                padding: "1rem",
                boxSizing: "border-box"
            }}>
                {tab === 0 && <Overview description={description} />}
                {tab === 1 && <Syllabus lessons={lessons} />}
                {tab === 2 && <Comments comments={comments} />}
            </Box>

        </Paper>
    )
}

export default CourseDetailContent