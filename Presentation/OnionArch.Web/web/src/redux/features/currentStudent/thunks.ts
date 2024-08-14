import { createAsyncThunk } from "@reduxjs/toolkit";
import StudentAPI from "../../../utils/APIs/StudentAPI";

export const IsCurrentStudentAttendedToCourse = createAsyncThunk<boolean, number>(
    'Student/IsCurrentStudentAttendedToCourse',
    async (courseId: number) => {
        const response = await StudentAPI.IsCurrentStudentAttendedToCourse(courseId)
        return response.data
    }
)