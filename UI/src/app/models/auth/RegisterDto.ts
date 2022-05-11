export interface RegisterDto {
  email: string | null;
  password: string | null;
  confirmPassword: string | null;
  role: string | null;
  isActive: boolean;
  companyName: string;
  phoneNumber: string;
}
