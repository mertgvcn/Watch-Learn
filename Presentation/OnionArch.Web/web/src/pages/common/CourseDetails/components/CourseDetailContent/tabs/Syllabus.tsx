//models
import { LessonDTO } from '../../../../../../models/DTOs/LessonDTO'
//mui components
import { Accordion, AccordionDetails, AccordionSummary, Box, Divider, Stack, styled, Typography } from '@mui/material'
//icons
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import AccessTimeIcon from '@mui/icons-material/AccessTime';
//helpers
import { formatDuration } from '../../../../../../utils/TimeSpan';

type SyllabusType = {
    lessons: LessonDTO[]
}

const Syllabus = ({ lessons }: SyllabusType) => {
    return (
        <Stack direction="column" spacing={2}>

            {lessons.map((lesson, index) => (
                <Accordion variant='outlined' key={index}>
                    <AccordionSummary
                        expandIcon={<ExpandMoreIcon />}
                    >
                        <Box sx={{
                            width: "100%",
                            display: "flex",
                            justifyContent: "space-between",
                            alignItems: "center",
                            marginRight: "1rem"
                        }}>
                            <Typography>{lesson.title}</Typography>
                            <IconTextBox>
                                <AccessTimeIcon sx={{ fontSize: 18 }} />
                                <Typography>{formatDuration(lesson.duration)}</Typography>
                            </IconTextBox>
                        </Box>
                    </AccordionSummary>

                    <Divider sx={{ marginBottom: "0.5rem" }} />

                    <AccordionDetails>
                        {lesson.description}
                    </AccordionDetails>
                </Accordion>
            ))}

        </Stack>
    )
}

export default Syllabus


const IconTextBox = styled(Box)({
    display: "flex",
    alignItems: "center",
    gap: "8px"
})