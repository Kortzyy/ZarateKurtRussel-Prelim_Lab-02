# Zarate Kurt Russel Prelim_Lab 02

**Prelim Activity 02: Advanced Object-Oriented Programming and Robustness**

**Kurt Russel B. Zarate**

**BSIT - 3.2**

# Task Description
This project bridges the gap between conceptual OOP design and practical system implementation by simulating a real-world medical storage monitoring system. 
 Users evolve from simple console input handling to full Systems Design using the pillars of Object-Oriented Programming: 
 * Inheritance 
 * Encapsulation 
 * Polymorphism
 * Abstraction
 * Exception Handling

# Project Objective

The objective of this system is to:
* Implement an OOP-based architecture for medical storage monitoring
* Create a class hierarchy using inheritance (MedicalStorage → UltraColdFreezer / StandardFridge)
* Enforce encapsulation using private fields and validated public properties
* Implement polymorphism for unique temperature thresholds and alarm behavior
* Use an interface (IAlertable) for mandatory alarm functionality
* Handle exceptions such as invalid operations including open-door events exceeding 30 seconds
* Produce real-time diagnostic output indicating system health and alarm status

# Object-Oriented Programming
**Encapsulation**

* All class fields are private
* Public properties validate temperature input
* StorageID protects against null or empty identifiers
  
**Inheritance**

* MedicalStorage serves as the base class
* UltraColdFreezer and StandardFridge inherit and extend its behavior
* Constructors use the base() syntax to pass shared data

**Polymorphism**

* The base class provides a virtual CheckTemperature() method
* Each subclass overrides the method with its own temperature threshold logic

**Abstraction**

* The IAlertable interface defines the required TriggerAlarm() method
* Any alert-capable storage unit must implement this behavior

# Exception Handling

The system uses C# exception tools to ensure robustness:

**Handled Exceptions**
* InvalidOperationException when the door remains open longer than 30 seconds
* ArgumentException for invalid temperature or ID inputs

**Try Catch Finally**
* The main execution flow is wrapped in a full error-protection block
* The finally section prints “System Shutdown” to ensure consistent termination

# System Logic Flow

* User or automated input sets the StorageID and CurrentTemp
* The system identifies the storage type (UltraColdFreezer or StandardFridge)
* The overridden CheckTemperature() method validates the temperature
* If the temperature exceeds safe limits, TriggerAlarm() executes
* If the door remains open for too long, an exception is raised and logged
* System logs all operations and safely concludes execution

# Project Structure
* `Program.cs`// Main execution and global error handling
* `Models`
   * `MedicalStorage.cs`   // Base class with shared logic
   * `UltraColdFreezer.cs` // Subclass with unique low-temp threshold
   * `StandardFridge.cs`   // Subclass with standard-temp threshold
* `Interfaces`
   * `IAlertable.cs`       // Defines mandatory TriggerAlarm() method

# How to Run

1. Open the solution file (Zarate_BioSafeVaccineMonitor.slnx) in Visual Studio
2. Build the solution (Ctrl + Shift + B)
3. Run the program (Ctrl + F5)


# Learning Outcomes

**This project demonstrates:**
* Practical application of Encapsulation, Inheritance, Polymorphism, and Abstraction
* Real-world modeling of medical safety systems
* Robust exception handling using structured try-catch-finally
* Clean architecture emphasizing modular design
* Effective use of interfaces to enforce system behavior contracts
