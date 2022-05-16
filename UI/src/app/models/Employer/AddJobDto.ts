export interface AddJobDto {
  jobTitle: string;
  closedDate: string;
  location: string;
  description: string;
  requirement: string;
  jobType: string;
  email: string | null;
  language: string | null;
  salary: string | null;
  website: string | null;
  jobCategoryId: string;
}
