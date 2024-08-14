//mui components
import { Box, Stack, styled, Typography } from '@mui/material'
//icons
import SubjectIcon from '@mui/icons-material/Subject';
import GroupIcon from '@mui/icons-material/Group';
import AccessTimeIcon from '@mui/icons-material/AccessTime';

type StatsType = {
    lessonCount: number,
    attendedStudentCount: number,
    totalLessonDuration: string
}

const Stats = (props: StatsType) => {
    return (
        <Stack direction="column" spacing={1}>
            <StatBox>
                <IconTextBox>
                    <SubjectIcon sx={{ fontSize: 18 }} />
                    <Typography variant='body1'>
                        Lessons
                    </Typography>
                </IconTextBox>
                <Typography variant='body1'>{props.lessonCount}</Typography>
            </StatBox>

            <StatBox>
                <IconTextBox>
                    <GroupIcon sx={{ fontSize: 18 }} />
                    <Typography variant='body1'>
                        Attendees
                    </Typography>
                </IconTextBox>
                <Typography variant='body1'>{props.attendedStudentCount}</Typography>
            </StatBox>

            <StatBox>
                <IconTextBox>
                    <AccessTimeIcon sx={{ fontSize: 18 }} />
                    <Typography variant='body1'>
                        Total Duration
                    </Typography>
                </IconTextBox>
                <Typography variant='body1'>{props.totalLessonDuration}</Typography>
            </StatBox>
        </Stack>
    )
}

export default Stats

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