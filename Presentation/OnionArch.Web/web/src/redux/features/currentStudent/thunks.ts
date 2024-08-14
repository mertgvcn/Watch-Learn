import { createAsyncThunk } from "@reduxjs/toolkit";
import StudentAPI from "../../../utils/APIs/StudentAPI";
import { CourseViewModel } from "../../../models/viewModels/CourseViewModel";

export const GetCoursesAttendedByCurrentStudent = createAsyncThunk<CourseViewModel[]>(
    'Student/GetCoursesAttendedByCurrentStudent',
    async () => {
        const response = await StudentAPI.GetCoursesAttendedByCurrentStudent()
        return response.data
    }
)

export const IsCurrentStudentAttendedToCourse = createAsyncThunk<boolean, number>(
    'Student/IsCurrentStudentAttendedToCourse',
    async (courseId: number) => {
        const response = await StudentAPI.IsCurrentStudentAttendedToCourse(courseId)
        return response.data
    }
)